using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTaskForVacansion1.Factory;
using TestTaskForVacansion1.Repository;
using TestTaskForVacansion1.Business;
using TestTaskForVacansion1.Models;

namespace TestTaskForVacansion1
{
    public partial class MainForm : Form
    {
        private IShipmentRepository _shipmentRepository;
        private IGroupByService<Shipment> _shipmentGroupByService;
        private IDictionary<string, bool> _visibleColumns;

        public MainForm()
        {
            InitializeComponent();

            _visibleColumns = new Dictionary<string, bool>()
            {
                { "RegistrationDate", false },
                { "Organization", false },
                { "City", false },
                { "Country", false },
                { "Manager", false }
            };

            _shipmentRepository = ShipmentServiceFactory.CreateShipmentRepository();
            _shipmentGroupByService = ShipmentServiceFactory.CreateShipmentGroupByService();

            _shipmentGroupByService.GroupByQueryBuilder.AddSumField("Quantity");
            _shipmentGroupByService.GroupByQueryBuilder.AddSumField("Price");

            checkBox1.CheckedChanged += GroupByCheckBoxEvent;
            checkBox2.CheckedChanged += GroupByCheckBoxEvent;
            checkBox3.CheckedChanged += GroupByCheckBoxEvent;
            checkBox4.CheckedChanged += GroupByCheckBoxEvent;
            checkBox5.CheckedChanged += GroupByCheckBoxEvent;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _shipmentRepository.GetAll();
        }

        private void VisibleDataGridViewColumns()
        {
            foreach (KeyValuePair<string, bool> column in _visibleColumns)
            {
                dataGridView1.Columns[column.Key].Visible = column.Value;
            }
        }

        private void GroupByCheckBoxEvent(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            void SetGroupField(string field)
            {
                if (checkBox.Checked)
                {
                    _shipmentGroupByService.GroupByQueryBuilder.AddGroupField(field);
                    _visibleColumns[field] = true;
                }
                else
                {
                    _shipmentGroupByService.GroupByQueryBuilder.RemoveGroupField(field);
                    _visibleColumns[field] = false;
                }
            }

            switch (checkBox.Name)
            {
                case "checkBox1": SetGroupField("RegistrationDate"); break;
                case "checkBox2": SetGroupField("Organization"); break;
                case "checkBox3": SetGroupField("City"); break;
                case "checkBox4": SetGroupField("Country"); break;
                case "checkBox5": SetGroupField("Manager"); break;
            }

            dataGridView1.DataSource = _shipmentGroupByService.GetGroupedObjects();
            VisibleDataGridViewColumns();
        }
    }
}
