using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using MultiplyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace MultiplyWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class PharmacyDrugController : Controller
    {
        public readonly IConfiguration _configuration;

        public PharmacyDrugController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        //[Route("[controller]")]
        [Route("CreateDrug")]
        public int CreateDrug(PharmacyDrugMaster _drugMaster)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand com = new SqlCommand("api_CreatePharmacyDrug", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@ItemCode", _drugMaster.DrugCode);
            com.Parameters.AddWithValue("@ItemName", _drugMaster.DrugName);
            com.Parameters.AddWithValue("@MoleculeName", _drugMaster.DrugMoleculeName);
            com.Parameters.AddWithValue("@ItemGroup", _drugMaster.DrugGroup);
            com.Parameters.AddWithValue("@ItemCategory", _drugMaster.DrugCategory);
            com.Parameters.AddWithValue("@DispencingType", _drugMaster.DispensingType);
            com.Parameters.AddWithValue("@ItemCompany", _drugMaster.ManufacturedBy);
            com.Parameters.AddWithValue("@ItemRoute", _drugMaster.DrugRoute);
            com.Parameters.AddWithValue("@ItemUOM", _drugMaster.BaseUnitOfMeasurement);
            com.Parameters.AddWithValue("@BaseMRP", _drugMaster.BaseMRP);
            com.Parameters.AddWithValue("@BaseCP", _drugMaster.BaseCostPrice);
            com.Parameters.AddWithValue("@LifeHisItemId", _drugMaster.HISDrugID);


            try
            {
                com.Parameters.Add("@ResultStatus", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                result = 200;
                return result;
            }

            catch (Exception ex)
            {
                result = 204;
                return result;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }


        }

        [HttpGet]
        [Route("GetPharmacyItemList")]
        public List<PharmacyItem> GetPharmacyItemList()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var PharmacyItemList = new List<PharmacyItem>();

            SqlCommand com = new SqlCommand("api_GetItemNames", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var PharmacyItem = new PharmacyItem
                    {
                        ItemName = Convert.ToString(reader["ItemName"]),
                        ItemGroup = Convert.ToString(reader["GroupName"]),
                        ItemCategory = Convert.ToString(reader["CategoryName"]),
                        BaseUnitOfMeasurement = Convert.ToString(reader["SalesUOM"]),
                        BatchesRequired = Convert.ToBoolean(reader["BatchesRequired"]),
                        UseOfExpiryDate = Convert.ToBoolean(reader["UseOfExpiryDate"]),
                        GSTApplicable = Convert.ToBoolean(reader["GSTApplicable"])
                    };
                    PharmacyItemList.Add(PharmacyItem);
                }

                return PharmacyItemList;
            }

        }
        [HttpGet]
        //[Route("[controller]")]
        [Route("GetItemGroups")]
        public List<ItemGroup> GetItemGroups()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var GroupList = new List<ItemGroup>();

            SqlCommand com = new SqlCommand("api_GetItemGroup", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var itemGroup = new ItemGroup
                    {
                        GroupName = Convert.ToString(reader["ItemGroup"])
                    };
                    GroupList.Add(itemGroup);
                }

                return GroupList;
            }

        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetItemCategories")]
        public List<ItemCategory> GetItemCategories()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var ItemCategoryList = new List<ItemCategory>();

            SqlCommand com = new SqlCommand("api_GetItemCategory", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var ItemCategory = new ItemCategory
                    {
                        CategoryName = Convert.ToString(reader["ItemCategory"])
                    };
                    ItemCategoryList.Add(ItemCategory);
                }

                return ItemCategoryList;
            }

        }

        [HttpGet]
        //[Route("[controller]")]
        [Route("GetUnitOfMeasurements")]
        public List<ItemUnitOfMeasurement> GetUnitOfMeasurements()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            if (con.State == ConnectionState.Closed)
                con.Open();
            var ItemUoMList = new List<ItemUnitOfMeasurement>();

            SqlCommand com = new SqlCommand("api_GetItemUOMS", con);
            com.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    var ItemUoM = new ItemUnitOfMeasurement
                    {
                        UoMName = Convert.ToString(reader["UoMName"])
                    };
                    ItemUoMList.Add(ItemUoM);
                }

                return ItemUoMList;
            }

        }

    }
}