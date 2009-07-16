using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FluentExamples.StoredProcExamples
{
    public class StoredProcExamples
    {
        // 18 lines
        public DataSet GetData(int id,
                               int childId,
                               string title,
                               string description,
                               int count)
        {
            DataSet ds;
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("GetData");
                db.AddInParameter(dbCommand, "Id", DbType.Int32, id);
                db.AddInParameter(dbCommand, "ChildId", DbType.Int32, childId);
                db.AddInParameter(dbCommand, "Title", DbType.String, title);
                db.AddInParameter(dbCommand, "Description", DbType.String, description);
                db.AddInParameter(dbCommand, "Count", DbType.Int16, count);
                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                // handle exception
                throw;
            }
            return ds;
        }

        // 7 lines
        public DataSet GetData2(int id,
                                int childId,
                                string title,
                                string description,
                                int count)
        {
            return StoredProc.Using("GetData")
                .AddParam("Id", id)
                .AddParam("ChildId", childId)
                .AddParam("Title", title)
                .AddParam("Description", description)
                .AddParam("Count", count)
                .ExecuteAndReturnDataSet();
        }
    }
}