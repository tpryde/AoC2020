   M S B A M L   `   `   `  ����G  CAdventOfCode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AdventOfCodeAdventOfCode  5   	       AdventOfCode.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AdventOfCode     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowState$ Normal=�5	   	    � Title$ Advent Of Code��5
   	   $	��600��6    $
��1000��6-   .��5      �  � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6U   $
��Left=�6b   $��	10,10,0,0q�6}   $	��Top=�6�   $	��165��6�   ��6   �� *Days+ �� SelectedItem 60   �� *SelectedDay+6�   �� 5   
   $��Run Part One��67   $��0��6N   $
��Left=�6[   $��
180,10,0,0q�6v   $	��Top=�6�   $��22��6�   $	��100��6�   ��6   �� *RunPartOneCommand+6�   �� 5   
   $��Run Part Two��67   $��0��6N   $
��Left=�6[   $��
285,10,0,0q�6v   $	��Top=�6�   $��22��6�   $	��100��6�   ��6   �� *RunPartTwoCommand+6�   �� 5   
   $��Consolas)�6Q   $��0��6g   $	��200��6t   $��22��6�   $
��Left=�6�   $	��Top=�6�   $��
390,10,0,0q�6�   $��Center=�6�   ��6   �� *
TestName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Create Test��67   $��0��6M   $
��Left=�6Z   $��
595,10,0,0q�6u   $	��Top=�6�   $��22��6�   $	��100��6�   ��6   �� *CreateTestCommand+6�   �� 5   
   $ ��Run All Tests For All Days��68   $��1��6]   $
��Left=�6j   $��	10,10,0,0q�6�   $	��Top=�6�   $��22��6�   $	��165��6�   ��6   �� *RunAllTestsCommand+6�   �� 5   
   $ ��Run All Tests For This Day��6:   $��1��6_   $
��Left=�6l   $��
180,10,0,0q�6�   $	��Top=�6�   $��22��6�   $	��205��6�   ��6   �� *RunTodayTestsCommand+6�   � 5   
   $��2��6    5       �� 5!      $��* �6#   �� 5"      $��5 �6#   �� 5#      $��* �6#   .+�5%      �� $��Input��6   $
��Left=�6$   $��	10,10,0,0q�6?   $��0��6R   $	��Top=�6b   �� 5&      $��0��61   $��Stretch=�6B   $��Stretch=�6`   $��10,40,10,10q�6|    �� TextWrapping$ NoWrap=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   "	 �� VerticalScrollBarVisibility$
	 Auto=�6�   
 �� AcceptsReturn$

 True��6�    �� 
AcceptsTab$
 True��6  $��Consolas)�6  ��6   �� *	InputText+6  �� 5'      $��1��6   $��Stretch=�6+   $��	0,40,0,10q�6I   �� 5(      $��Output��6   $��2��6%   $
��Left=�65   $��	10,10,0,0q�6P   $	��Top=�6c   #   AdventOfCode.ScrollingTextBox  5)      $��2��6A    �� 
IsReadOnly$
 True��6Q   $��Stretch=�6c   $��10,40,10,10q�6�   $ NoWrap=�6�   $��Stretch=�6�   $
	 Auto=�6�   $
 Auto=�6�   $

 True��6  $
 True��6%  $��Consolas)�67  ��6%   �� *
OutputText+67  5*      5,      5-      