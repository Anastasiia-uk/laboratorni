   M S B A M L   `   `   `  ����I  EFileManagerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FileManagerWPFFileManagerWPF  5   	       FileManagerWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:FileManagerWPF     5   	     � Title$  FileManager��5   	   $	��350��6   $	��525��6*    � 	Resources 5	         DataTemplateForIcon �� CellTemplate �� Orientation �� Path  DataTemplateForName  DataTemplateForFreeSpace  DataTemplateForTotalSize   DataTemplateForLastWriteTime   FileManagerWPF.TileView  TileView   ItemTemplate  GridView " DataTemplateTreeViewItemHeader �� DataType��%z  &	        &	 �     &	 T    &	 �    &	 T    &	 �    &	 �    &	 L    �� 5   
   $
��Icon��65    5      �� 5      .R�5      �� $ 
Horizontal=�6!   .+�5      �� $��UniformToFill=�6=   $��25��6U   $��25��6d   ��6    �� $
 Icon�6d   5      5      5      �� 5   
   $
��Name��65    5      �� 5      .R�5      �� ��6    �� $
 Name�5      5      �� 5   
   $��
Free space��6:    5      �� 5      .R�5       �� ��6    �� $ 	FreeSpace�5!      5#      �� 5%   
   $��
Total size��6:    5&      �� 5'      .R�5(      �� ��6    �� $ 	TotalSize�5)      5+      �� 5-   
   $��Last write time��6>    5.      �� 5/      .R�50      �� ��6    �� $ LastWriteTime�51      53        55   
    56      �� 57      .R�58      �� .+�59      �� $��UniformToFill=�6=   $��50��6U   $��50��6d   ��6    �� $
 Icon�6d   �� 5:      ��6$   �� $
 Name�5;      5<      5>      �� 5@   
   .P�5A      �� $
��Name��6    5B      �� 5C      .R�5D      �� ��6$   �� $
 Name�5E      5G      5H      �� 5J   
   $ local:DirectoryContent��6>   .R�5K      �� .+�5L      �� $��UniformToFill=�65   $��10��6M   $��10��6\   ��6   �� $
 Icon�6\   �� 5M      ��6   �� $
 Name�5N      5O      5P      .��5Q      �  � ColumnDefinitions 5R   
   �� 5S      $
��333* �6   �� 5T      $
��184* �6    � RowDefinitions 5V   
   �� 5W      $
��Auto �6   6,   �� 5X      6   .+�5[   
   c� $��0��6   $��2��6   .@�5\      �� -   5        $��TextBox��5\      $	��200��6%   	 �� 	MaxLength$		 500��64   
 �� MaxLines$
 1��6D   6Q   �� 5]      6   �� 5^      $��Center=�6   $��5 0 5 0q�63   
View mode:6P   �� 5_      -   5        $��ComboBox��5_      $	��100��6'   $��Center=�66   $��Center=�6Z   .@�5`      ��  �� 
IsSelected . $��Center=�61   .��6U   
GridView6_   �� 5a      $��Center=�6   .��6C   
TileView6M   5c      �� 5d      6   �� 5e       d� 	IsChecked$ FalseY�6   $y�Hidden=�6)   .��6=   
Grouping6G   5f      � 5g   
   $��1��6   $��2��6    5h      �� 5i      $��* �6#   6/   �� 5j      $��2* �6#   60   .+�5l      R� -   5        $��TreeView��5l   '   $��0��6   5r      �� 5s      -   5        $��ListView��5s   '   $��1��6    �� View# [ 67   6�   5t      5u      5v      