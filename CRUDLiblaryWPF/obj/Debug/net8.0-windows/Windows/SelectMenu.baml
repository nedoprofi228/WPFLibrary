   M S B A M L   `   `   `  ����I  ECRUDLiblaryWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CRUDLiblaryWPF.WindowsCRUDLiblaryWPF.Windows  5   	   '    !CRUDLiblaryWPF.Windows.SelectMenu   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   6local$clr-namespace:CRUDLiblaryWPF.Windows     5   	     � Title$  Выбор Книг��5   	   $	��350��6   $	��525��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $$��Доступные книги:��6   $��10q�6,   $��16(�68   $��0��6F   $��0��6S   �� 5   
   $)��#Информация о книге:��6   $��10q�6/   $��16(�6;   $��0��6I   $��1��6V   �� 5   
   -   5         ��Name$ IsFavoriteCheckBox��5   0   $��0��6   $��1��6    $��Right=�6L   $��10q�6h   $	��120��6t   $��20��6�   $#��избранные книги��6�   6�   � 5   
   $��0��6   $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	BooksList��5         AutoGenerateColumns$ False��6*   $��10q�6F      CanUserResizeRows$ False��6R      CanUserResizeColumns$ False��6l      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6H   
   
IsReadOnly$

 True��6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   ��  �� Path$ Title�6R   5      5      � 5!   
   $��1��6   $��1��6    5"      �� 5#      $
��Auto �6    �� 5$      $��* �6    .+�5&      �� -   5        $��BookInfo��5&   1   $��0��6   $��15q�6%   $3��-Выберите книгу из списка��6A   $
��Wrap=�6a   $��14(�6u   �� 5(      $��1��6   $��10q�6"   $��1q�6.   
���   �._�5)      �� -   5        $��BookText��5)      $
��Wrap=�6,   $��14(�6@   5*      5+      � 5.   
   $��2��6   $��2��6    5/      �� 50      $��* �6#   �� 51      $��* �6#   �� 52      $��* �6#   .+�55      �� -   5         ��Name$ 
AddBookBtn��55   .   $!��Добавить книгу��6   $��Center=�6B   $��Bottom=�6_   $��10q�6z   $��0��6�   6�   �� 56      -   5        $ DeleteBookBtn��56   -   $��Удалить книгу��6   $��Center=�6D   $��Bottom=�6a   $��10q�6|   $��1��6�   6�   �� 57      -   5        $ AddToFavoriteBtn��57   4   $,��&Добавить в избранное��6   $��Center=�6N   $��Bottom=�6k   $��10q�6�   $��2��6�   6�   58      59      5:      