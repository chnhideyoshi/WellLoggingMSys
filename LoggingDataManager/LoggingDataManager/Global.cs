using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace LoggingDataManager
{
    public static class Global
    {
        public static double DeepPanel_BaseHeight = 0;
        public static double DeepPanel_CurveUnitSegment = 0.5;
        public static int DeepPanel_VerticalGraduationCount = 20;
        public static int DeepPanel_VerticalOffset = 0;
        public static int GridMap_HorizontalCellsCount = 8;

        public static void InitConfiguration()
        {
            
        }

        public static string ImageJPath=@"Files\ij.jar";
    }
    internal static class GlobalControlCache
    {
        static Dictionary<Type, Control> controlCache = new Dictionary<Type, Control>();
        public static void ReserveControl(Control c)
        {
            if(controlCache.ContainsKey(c.GetType()))
            {
            }
            else
            {
                controlCache.Add(c.GetType(),c);
            }
        }
        public static bool ExistControl(Type p)
        {
            return controlCache.ContainsKey(p);
        }
        public static T GetInstance<T>() where T : Control
        {
            return controlCache[typeof(T)] as T;
        }
    }
}
