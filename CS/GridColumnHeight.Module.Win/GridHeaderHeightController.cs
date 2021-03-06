using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Persistent.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using XAFCommunity.Win;

namespace GridColumnHeight.Module.Win
{
    public partial class GridHeaderHeightController : ViewController
    {
        public GridHeaderHeightController()
        {
            InitializeComponent();
            RegisterActions(components);

            TargetViewType = ViewType.ListView;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            View.ControlsCreated += View_ControlsCreated;
        }

        protected override void OnDeactivated()
        {
            View.ControlsCreated -= View_ControlsCreated;
            base.OnDeactivated();
        }

        void View_ControlsCreated(object sender, EventArgs e)
        {
            IModelListViewHeaderRows modelListViewHeaderRows = this.View.Model as IModelListViewHeaderRows;
            if (modelListViewHeaderRows != null) 
            {
                SetColumnHeadingRowHeight(View as ListView, modelListViewHeaderRows.HeaderRows);
            }
        }

        /// <summary>
        /// Configures the supplied ListView grid to show word wrapped column captions.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="lineCount">The number of lines of text required in the column header.</param>
        internal static void SetColumnHeadingRowHeight(ListView view, int lineCount)
        {
            if (view != null && lineCount > 1)
            {
                GridListEditor listEditor = view.Editor as GridListEditor;
                if (listEditor != null)
                    GridHeaderHeightHelper.SetGridEditorHeaderHeight(listEditor, lineCount);
            }
        }
    }
}