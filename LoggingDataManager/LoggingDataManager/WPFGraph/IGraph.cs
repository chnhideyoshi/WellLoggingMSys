using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggingDataManager.WPFGraph
{
    public interface IGraph
    {
        double CurrentDepth { get; set; }
        double CurveXMaxValue { get; }
        double CurveXMinValue { get; }
        double MaxUnitLength { get; }
        void RepaintAll();
        double UnitLength { get; set; }
        int VerticalCellsCount { get; set; }
        int HorizontalCellsCount { get; set; }
        double XPresentRange { get; }
        double XRange { get; }
        double ViewHeight { get; }
        double ViewWidth { get; }
        bool ShowGridLine { get; set; }
    }
}
