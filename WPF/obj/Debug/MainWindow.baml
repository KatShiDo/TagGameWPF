   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	       WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WPF     5   	     � 
ResizeMode$  NoResize=�5   	   $��40(�5	   	    � Title$ 
MainWindow��5
   	   $	��600��6   $	��600��6)    � 	Resources 5      !   WPF.DateTimeToDateConverter   cnv��%   &	          5   
   6(   5      .��5      �  5   
    �� 
TargetType �� Property �� Value��%~   '��       �� 5      " ��6   .�5      ��  � ��$ 40(�6-   6:   �� 5       � �� �#4446>   5      5      .+�5      �� -   5         ��Name$ ic��5      $��Center=�6'   $��Center=�6D   $��50q�6_   ��5      �� 5      .R�5      �� ��6'   �� ��5      �� 5   "   .R�5   &   ��  �� Orientation$ 
Horizontal=�61   6L   5   #   ��5      �� 5    "   .R�5!   &   �� -   5         �� Padding$ 20q�5!   -   $��3q�6:   $��2q�6E   
����������#EEE$	��100��5"   T   $	��100��6`   	 �� CornerRadius$	 10��5#   -   
 J� Opacity
 6?   ��  �� 	Converter# [   J� BitmapEffect 5%   *   F� 5&   .    F� ShadowDepth$ 5Q�6E    F� Opacity$	 0.2Q�6U   6e   ._�5(   *   �� $��40(�6E   $��Center=�6S   ���#444��64   ��  5*   .   F� 5+   2   $ 4Q�6I   $	 0.5Q�6Y   6i   5-   +   5.   '   5/   #   51      52      54      �� 55   
   -   5        $��tblStep��55      $��Right=�6#   $	��Top=�6?   $��10q�6W   6e   �� 56   
   -   5        $��tblTimer��56      $
��Left=�6$   $	��Top=�6?   $��10q�6W   6e   �� 58   
   -   5         ��Name$	 brd��58      ���#8000$��Stretch=�61   $��Stretch=�6O   $y�	Collapsed=�59      ._�5:      � .+�5;      �� $��
YOU WIN!!!��6   
��� ���$
��Bold"�6B   $��Center=�5<      $	��Top=�69   6S   �� 5=      ���#8000$��10, 70, 10, 10q�6,   $��Center=�6D   $	��Top=�5>      $	 20��61   ._�5?      �� -   5        $ records��5?   #   $��20(�64   
���������5@      �� 5A      .R�5B   "   �� $ 
Horizontal=�6-   .+�5C   &   ��  �� TextAlignment$ Right=�6E   $��50��6[   ��60   �� *Pos+6h   �� 5D   &   $��: ��60   6<   �� 5E   &   $
 Left=�6F   $	��200��6[   ��60   �� *Date+6i   �� 5F   &   $ Center=�6F   $��80��6]   ��60   �� *Time+6j   �� 5G   &   $ Center=�6G   $��80��6^   ��60   �� *Steps+6k   5H   #   5I      5K      5L      � 5M      $��Center=�6   $��Bottom=�64    � ColumnDefinitions 5N      �� 5O      $��* �6+   67   �� 5P      $��* �6+   67   .+�5R      �� -   5        $�� Again? ��5R      $��10q�5S      $��30(�6)   $	��160��67   6E   �� 5T      -   5        $��1��5T      $�� Exit ��6-   $��10q�5U      $��30(�6)   $	��160��67   6E   5V      5W      5Y      5Z      5[      