   M S B A M L   `   `   `  ���� ?  ;IZIN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MURPMURP      MURP.MainWindow   rootclr-namespace:MURP  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
IZIN DOSEN��$	��650��$
��1006��   TemplateWindow#��[  .��� $��20, 10q�.+��� -   $��panel1��
�������z�V� .~��� ��  �� AngleY$ -0.096Q��� T�  T� Y$ -0.772Q�.+��� -   $��button2��$��33��$	��109��$��4��
�������$��0q�$��Right=�$��Bottom=� �� Left$	 474��
 �� Top$ 16��.��	Refresh�� -   $��button1��$��33��$	��109��$��1��
�������$��0q�$��Right=�$��Bottom=�$ 39��$ 16��.��New&   System.Windows.Controls.DataGrid  -   $��table��   AutoGenerateColumns .     CanUserAddRows .  $	��366��$
��1200��$��Right=�$��Bottom=�$ 81������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Kode Dosen��	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 ��  �� Path$ kdDosen� �� UpdateSourceTrigger$ PropertyChanged=�  $ 
Nama Dosen��$
	 Auto 
 �� $ nmDosen�$ PropertyChanged=�  $ Tanggal Izin��$
	 Auto 
 �� $ tglPengajuanIzin�$ PropertyChanged=�  $ Jam Izin��$
	 Auto 
 �� $ jamPengajuanIzin�$ PropertyChanged=�  $ Alasan Izin��$
	 Auto 
 �� $ 
alasanIzin�$ PropertyChanged=�  $ Status��$
	 Auto    
IsReadOnly . 
 �� $ status�$ PropertyChanged=�4  .System.Windows.Controls.DataGridTemplateColumn  $
 Aksi��$
	 Auto    CellTemplate �� .R��� -   .��Hapus4  .System.Windows.Controls.DataGridCheckBoxColumn  $ Approval��
 �� $ 	isChecked�$ PropertyChanged=��� -    ��Name$ Approval��$��33��$	��109��$��4��
�������$��0q�$��Right=�$��Bottom=�$	 606��$ 16��$��Approve���� -   $ export_excel��$��33��$	��109��$��4��
�������$��0q�$��Right=�$��Bottom=�$	 754��$ 16��$��Report���� -   $ Approval_Copy��$��33��$	��109��$��4��
�������$��0q�$��Right=�$��Bottom=�$	 606��$ 16��$��Approve��