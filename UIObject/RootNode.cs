﻿using AdminServerObject;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace UIObject
{
    public class RootNode : Node
    {
        private ListItem addAdminServerItem ;
        public RootNode(JToken token) : base(token)
        {
            nodeType = NodeType.RootNode;
            obj  = (dynamic)token["addAdminServerItem"];
            addAdminServerItem = new ListItem(token["addAdminServerItem"]);
            addAdminServerItem.ListItemType = ListItemType.AddAdminServerItem;
        }

        public void handleSelectEvent( ListView listView, SortedDictionary<string, AdminServer> adminServerList)
        {
            ListItem listItem;
            initListView(listView);
            foreach (string key in adminServerList.Keys)
            {
                listItem = new ListItem();
                listItem.ListItemType = ListItemType.AdminServerItem;
                listItem.relatedNode = (Node)Nodes.Find(key, true)[0];
                listItem.Text = key;
                listItem.Name = listItem.Text;
                listItem.ImageIndex = 2;
                listView.Items.Add(listItem);
            }
            listView.Items.Add(this.addAdminServerItem);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
       /*
       public Node findChildNodeByName(string childNodeName)
       {
           Node childNode = null;
           foreach (Node node in this.Nodes)
           {
               if (node.Name.Equals(childNodeName))
               {
                   childNode = node;
                   break;
               }
           }
           return childNode;
       }*/
    }
}