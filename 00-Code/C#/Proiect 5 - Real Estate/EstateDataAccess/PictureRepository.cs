using EstateDataAccess;
using EstateDataAccess.Repository;
using EstateModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EstateDataAccess.Repository.SqlRepository
{
    internal class PictureRepository : SQLRepository<Picture>
    {
        //int Id
        //string Name
        //long Size
        //DateTime CreateDate


        //public new Picture Create(Picture value)
        //{
        //    string strInsert = $"insert into Picture(Name,CreateDate,Size) values ('{value.Name}', '{value.CreateDate}', '{value.Size}')";

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(strInsert, con);
        //        con.Open();
        //        cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: Inserting picture.\n" + strInsert + "\n");

        //        Console.WriteLine(ex.Message);
        //    }
        //    con.Close();

        //    return value;
        //}

        //    public new Picture Update(Picture value)
        //    {
        //        string strUpdate = $"UPDATE Picture SET Name='{value.Name}' WHERE PictureId={value.Id}";

        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand(strUpdate, con);
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine($"Error: Updating log with code `{value.Id}`\n" + e.ToString());
        //        }
        //        con.Close();

        //        return value;
        //    }
    }
}
