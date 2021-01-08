using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VisualComponents.Nazarova
{
    public partial class ControlTreeView : UserControl
    {

        private List<(string, bool)> Hierarchy { get; set; } 

        public int SelectedIndex
        {
            get { return treeView.SelectedNode.Index; }
            set
            {
                var temp = treeView.SelectedNode;
                treeView.Nodes.Remove(temp);
                treeView.Nodes.Insert(value, temp);
            }
        }

        public ControlTreeView()
        {
            InitializeComponent();
        }

        public void Configure(List<(string, bool)> lst)
        {
            Hierarchy = lst;
        }

        public string GetSelectedValue()
        {
            if (treeView.SelectedNode != null)
            {
                return treeView.SelectedNode.Text;
            }
            else
            {
                return "";
            }
        }

        public void AddElem<T>(T obj, string propEnd)
        {
            var Nodes = treeView.Nodes;
            foreach (var prop in Hierarchy)
            {
                if (prop.Item2)
                { 
                    var nn = new TreeNode(Convert.ToString(typeof(T).GetProperty(prop.Item1).GetValue(obj)));
                    Nodes.Add(nn);
                    Nodes = nn.Nodes;
                }
                else
                {
                    TreeNode flag = null;
                    foreach (TreeNode node in Nodes)
                    {
                        if (node.Text == Convert.ToString(typeof(T).GetProperty(prop.Item1).GetValue(obj)))
                        {
                            flag = node;
                            break;
                        }
                    }
                    if (flag == null) 
                    {
                        var nn = new TreeNode(Convert.ToString(typeof(T).GetProperty(prop.Item1).GetValue(obj)));
                        Nodes.Add(nn);
                        Nodes = nn.Nodes;
                    }
                    else 
                    {
                        Nodes = flag.Nodes;
                    }
                }

                if (prop.Item1 == propEnd)
                {
                    break;
                }
            }
        }
    }
}