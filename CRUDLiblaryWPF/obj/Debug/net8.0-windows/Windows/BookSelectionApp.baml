   M S B A M L   `   `   `  ����  CRUDLiblaryWPF!    BookSelectionApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Выбор Книг��5   	   $	��350��6   $	��525��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $$��Доступные книги:��6   $��10q�6,   $��16(�68   $��0��6F   $��0��6S   �� 5   
   -   5        $��BookList��5      $��10q�6"   $��1��6.   $��0��6;   .@�5      �� .��6   Книга 16#   �� 5      .��6   Книга 26#   �� 5      .��6   Книга 36#   5      �� 5   
   $)��#Информация о книге:��6   $��10q�6/   $��16(�6;   $��0��6I   $��1��6V   �� 5   
   -   5        $��BookInfo��5      $3��-Выберите книгу из списка��6$   $��10q�6D   $
��Wrap=�6P   $��14(�6d   $��1��6r   $��1��6   �� 5   
   $!��Добавить книгу��6   $
��Left=�6*   $��Bottom=�6E   $��10q�6`   $��2��6l   $��0��6y   �� 5   
   $��Удалить книгу��6   $��Right=�6)   $��Bottom=�6E   $��10q�6`   $��2��6l   $��1��6y   5      5      