   M S B A M L   `   `   `  ����K  GMR_Launcher_Lite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MR_Launcher_LiteMR_Launcher_Lite  5   	   I)clr-namespace:MR_Launcher_Lite.ConvertersMR_Launcher_Lite.Converters  5   	   !    MR_Launcher_Lite.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MR_Launcher_Lite     5   	   :conv)clr-namespace:MR_Launcher_Lite.Converters     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Motor Rock Launcher Lite��5   	   $	��650��5	   	   $	��950��5
   	      MaterialDesignBody#���   5   
   $��Regular"�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$ Aliased=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5      :   4MR_Launcher_Lite.Converters.FilenameToImageConverter  FilenameToImageConverter��%   &	         5   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   c� $��0��6     MaterialDesignToolBar#���  6   .@�5      �� -   5        .��5   6   Locate game folder6J   �� 5      -   5        .��5   -   	Scan mods68   �� 5      .��6   Choose music6#   �� 5       .��6   Choose gamemode6&   5!      � 5"   
   $��1��6   $	��920��6    5#      �� 5$      $
��Auto �6    �� 5%      .+�5(      �� $��0, 10q�6    �� Orientation$ Vertical=�6(   .+�5*      �� $ 
Horizontal=�6   .+�5,      �� $ 
Horizontal=�6!   .+�5-      �� $��90��6    $��Center=�6+   .��6F   Mod:6L   �� 5.      $	��200��6#   ��5/      �� *UnitOfWork.ModsService.Mods+ �� SelectedItem 50      �� *SelectedMod+��51      �� 52   "   .R�53   &   �� ��6,   �� *Name+54   #   56      �� 57      -   5        $	��115��58      $��15, 0q�59      $��Install mod��5:      5;      5<      �� 5>      $ 
Horizontal=�6!   .+�5?      �� $��90��6    $��Center=�6+   .��6F   	Gamemode:6Q   �� 5@      $	��200��6#   ��5A   #   �� *SelectedMod.GameModes+{�5B   #   �� *SelectedMod.GameModes.Count+��5C      �� 5D   "   .R�5E   &   �� ��6,   �� 5F   #   5H      �� 5I      -   5        $	��150��5I   !   $��15, 0q�5J   !   $��Install gamemode��5K   !    � Cursor$
 Hand��5L   D   5M      5N      �� 5P      $��0 5 0 0q�6   $ 
Horizontal=�6.   .+�5Q      �� $��90��6   $��Center=�6'   .��6B   Music pack:6O   �� 5R      $	��200��6   ��5S      �� *SelectedMod.AudioPacks+{�5T      �� *SelectedMod.AudioPacks.Count+��5U      �� 5V      .R�5W   "   �� ��6(   �� 5X      5Z      �� 5[      -   5        $��Install music��5[      $	��115��5\      $��15, 0q�5]      5^      5_      5`      � 5b      $��1��6   	 � ColumnDefinitions	 5c      �� 5d      �� 5e      .+�5g      �� $��0��6   .+�5h      ��  $  MaterialDesignHeadline3TextBlock#���  6    $
��Wrap=�5i   B   ��6    �� *SelectedMod.Name+6B   �� 5j       $  MaterialDesignHeadline6TextBlock#���  6    $
��Wrap=�5k   I   ��6    �� *SelectedMod.Description+6I   5l      �� 5m      $��1��6   .+�5n      �� $	��300��6   ��6(   �� 
 �� 	Converter#
 [  �� ConverterParameter$
 logo��5o      5p      5q      5r      5s      