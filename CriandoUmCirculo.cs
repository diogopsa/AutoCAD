using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;


namespace CriandoUmCirculo
{
    public class Class1
    {
        [CommandMethod("ci")]
        public static void CreateCircle()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            //start transaction
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                BlockTable blk = trans.GetObject(db.BlockTableId,OpenMode.ForRead) as BlockTable;
                BlockTableRecord blkrec = trans.GetObject(blk[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                //create a circle
                Circle newcircle = new Circle();
                newcircle.Radius = 2;
                newcircle.Center = new Point3d(0,0,0);
                // Add a circle to drawing
                blkrec.AppendEntity(newcircle);
                trans.AddNewlyCreatedDBObject(newcircle, true);
                trans.Commit();

            }
        }
    }
}
