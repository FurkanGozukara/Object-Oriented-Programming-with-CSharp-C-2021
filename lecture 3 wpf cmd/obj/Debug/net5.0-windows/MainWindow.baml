   M S B A M L   `   `   `  ����L  Hlecture 3 wpf cmd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:lecture_3_wpf_cmdlecture_3_wpf_cmd  5   	   "    lecture_3_wpf_cmd.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:lecture_3_wpf_cmd     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5        $��btnTest��5
   *   $��cmd start test��6   $
��Left=�69   $��	17,10,0,0q�6T   $	��Top=�6g   $��84��6   6�   �� 5   
   -   5         ��Name$
 txt1��5      $
��Left=�6    $��	17,45,0,0q�6;   $��	main text��6N    �� TextWrapping$
 Wrap=�6_    �� AcceptsReturn$
 True��6s    �� MaxLines$	 200��6�   $	��Top=�6�   $	��127��6�   ���	#FF9A2A2A$��88��6�   �� 5   
   -   5        $
 txt2��5      $
��Left=�6    $��
166,45,0,0q�6;   $��TextBox��6O   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5   
   -   5        $��btnMergeAndShow��5   *   $��merge and show��6   $
��Left=�6A   $��
319,43,0,0q�6\   $	��Top=�6p   $	��126��6�   6�   � 5   
   $��24,175,52,39q�6    � ColumnDefinitions 5      �� 5      $	��200��6#   $	��69* �62   6A   �� 5      $
��293* �6#   �� 5      $	��300��6#   $
��362* �62   6B    � RowDefinitions 5      �� 5      $	��200��6!   5      �� 5      $	��100��6    5      .+�5!      �� -   5        $��lstBox1��5!   `   $��10,10,10,10q�6o   $��0��6�   $��0��6�   $��2��6�   5#      �� 5$      -   5        $��lstBox2��5$   +   $��10,10,10,10q�6   $��2��6:   $��0��6x   5&      5(      �� 5)   
   -   5        $��txtSplit��5)   5   $
��Left=�6E   $��
24,150,0,0q�6`   $��
split text��6t   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��20��6�   �� 5*   
   -   5         ��Name$ btnSplit��5*      $��split��6#   $
��Left=�63   $��
323,82,0,0q�6N   $	��Top=�6b   $	��126��6z   6�   �� 5+   
   -	   5        $��btnClearListBox��5+   )   $��clear listbox��6   $
��Left=�6@   $��323,118,0,0q�6[   $	��Top=�6p   $	��126��6�   $��25��6�   6�   �� 5,   
   -
   5        $ txtListboxindex��5,      $
��Left=�6+   $��504,150,0,0q�6F   $��index��6[   $
 Wrap=�6h   $	��Top=�6|   $	��120��6�   �� 5-   
   -   5        $��txtEventBox��5-      $
��Left=�6%   $��
539,20,0,0q�6@   $��TextBox��6T   $
 Wrap=�6c   $	��Top=�6w   $	��158��6�   $��34��6�   �� 5.   
   -   5        $��btnChangeVisibility��5.   -   $��change visibility��6   $
��Left=�6H   $��
504,80,0,0q�6c   $	��Top=�6w   $��50��6�   $��89��6�   6�   �� 5/   
   -   5        $��btnRandomWindow��5/   /   $��start random window��6   $
��Left=�6F   $��
639,77,0,0q�6a   $	��Top=�6u   $��56��6�   $��80��6�   6�   52      53      