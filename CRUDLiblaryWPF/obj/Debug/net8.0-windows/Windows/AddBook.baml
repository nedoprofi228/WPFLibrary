   M S B A M L   `   `   `  ����I  ECRUDLiblaryWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CRUDLiblaryWPF.WindowsCRUDLiblaryWPF.Windows  5   	   $    CRUDLiblaryWPF.Windows.AddBook   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   6local$clr-namespace:CRUDLiblaryWPF.Windows     5   	     � Title$  AddBook��5   	   $	��250��6   $	��400��6&   .��5	      � -   5         �Name$
 Grid��5	       � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Center=�6-   $��Название:��6J   �� 5   
   -   5         ��Name$ TitleTextBox��5   L   $��1��6   $��0��6   $��Center=�6/   $	��300��6b   $��5q�6n    �� 	MaxLength$ 40��6y   �� 5   
   $��2��6   $��0��6   $��Center=�6-   $��Автор:��6J   �� 5   
   -   5        $ AuthorTextBox��5   L   $��3��6   $��0��6   $��Center=�6/   $	��250��6c   $��5q�6o   $ 40��6z   �� 5   
   $��4��6   $��0��6   $��Center=�6-   $��Текст:��6J   �� 5   
   -   5        $ TextTextBox��5   L   $��5��6   $��0��6   $��Center=�6/   $��10q�6a    �� AcceptsReturn$
 True��6m   " �� VerticalScrollBarVisibility$
 Auto=�6�    �� TextWrapping$
 Wrap=�6�   $	��350��6�   �� 5!   
   -   5        	 ��Name$	 
AddBookBtn��5!   K   $��6��6   $��0��6   $��Center=�6.   $��Добавить��6_   $	��100��6r   $��10q�6~   6�   5"      5#      