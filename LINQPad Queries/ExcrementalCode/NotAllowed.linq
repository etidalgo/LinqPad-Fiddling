<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

int alpha;
//alpha = (int)((uint)2 << (uint)15); // not allowed
//alpha = (int)((uint)2 << (ulong)15); 
alpha = (int)((uint)2 << (ushort)15); 
alpha = (int)((uint)2 << (int)15); 
alpha = (int)((uint)2 << 15); 
alpha = (int)2 << (int)1;

MessageBox.Show( "Something", "Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification); //   mb_OK + mb_Topmost + mb_Service_Notification)