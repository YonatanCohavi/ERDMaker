using ERDMaker.Services;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace ERDMaker
{
    public partial class MainControl : PluginControlBase
    {
        private const int MAX_RECOMENDED = 15;
        private Settings mySettings;
        private ICollection<string> _allEntities = new List<string>();
        private readonly DebounceDispatcher debounceTimer = new DebounceDispatcher();
        private HashSet<string> _selectedEntities = new HashSet<string>();

        public MainControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            _selectedEntities.Clear();
            _allEntities.Clear();
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void loadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        private void LoadEntities()
        {
            txt_filterEntities.Text = string.Empty;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Entities...",
                Work = (worker, args) =>
                {
                    args.Result = CRMService.GetAllEntities(Service);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (args.Result is ICollection<string> result)
                    {
                        lst_entities.Items.Clear();
                        _allEntities = result;
                        foreach (var item in result)
                        {
                            lst_entities.Items.Add(item, false);
                        }
                    }
                }
            });
        }

        private void txt_filterEntities_TextChanged(object sender, EventArgs args)
        {
            debounceTimer.Debounce(250, (p) => FilterList());
        }
        private void FilterList()
        {
            var filter = txt_filterEntities.Text;
            var filtered = _allEntities.Where(e => string.IsNullOrEmpty(filter) || e.Contains(filter));
            lst_entities.Items.Clear();
            foreach (var item in filtered)
            {
                lst_entities.Items.Add(item, _selectedEntities.Any(i => i == item));
            }
        }

        private void lst_entities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var index = e.Index;
            var item = lst_entities.Items[index] as string;
            if (e.NewValue == CheckState.Checked)
                _selectedEntities.Add(item);
            if (e.NewValue == CheckState.Unchecked)
                _selectedEntities.Remove(item);
            lst_selected.Items.Clear();
            lst_selected.Items.AddRange(_selectedEntities.OrderBy(i => i).ToArray());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (_selectedEntities.Count < 2)
            {
                MessageBox.Show($"You must select at least 2 entities.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_selectedEntities.Count >= MAX_RECOMENDED)
            {
                var res = MessageBox.Show($"Its recomended to select less then {MAX_RECOMENDED} entities\r\nDo you want to continue?", "Warning", MessageBoxButtons.YesNo);
                if (res != DialogResult.Yes)
                    return;
            }
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Generating Diagram",
                Work = (worker, args) =>
                {
                    var tables = CRMService.MapTables(Service, _selectedEntities);
                    var diagram = DiagramBuilder.StringifyTables(tables);
                    args.Result = diagram;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as string;
                    txt_result.Text = result;
                    Clipboard.SetText(result);
                    MessageBox.Show($"The Diagram was copied to the clipboard");
                }
            });
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://dbdiagram.io/");
        }
    }
}