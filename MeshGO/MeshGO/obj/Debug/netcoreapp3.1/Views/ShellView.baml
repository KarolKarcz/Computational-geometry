   M S B A M L   `   `   `  ����A  =MeshGO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MeshGO.ViewsMeshGO.Views  5   	       MeshGO.Views.ShellView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MeshGO.Views     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.0.1244, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $��Regular"�5   	     � WindowStyle$
  None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ 	Maximized=�5   	   $��0q�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � Title$ 	ShellView��5   	   $	��600��6   $
��1024��6(   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � $��2��6   ���	#FF8522BD.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5        	 ��Name$	 	OffButton��5       0  ,MaterialDesignFloatingActionMiniAccentButton#��[  6,   $��25��6r   $��25��6}   
���������6�   Z� ��6�   Z� .��5       '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Power=�6.   6=   5!      5"      5#      �� 5&   
   $��1��6   ���	#FFECECEC.+�5'      �� -   5        $	 
SIMPLEMESH��5'      ${�False��6)   $��10q�6;   ���	#FF8522BD���	#FF8522BD.��5(      � $	��150��6   .+�5)        $
 Build=�6.   $��Center=�6;   �� 5*      $��Center=�6    $��SIMPLE MESH��6=   $��Champagne & Limousines)�6P   5+      5,      �� 5.      -   5        $	 GENERATE��5.      $��10q�6'   ���	#FF8522BD���	#FF8522BD.��5/      � $	��150��6   .+�50        $
 Build=�6.   $��Center=�6;   �� 51      $��Center=�6    $��GENERATE��6=   $��Champagne & Limousines)�6M   52      53      �� 55      -   5        $	 
CONVEXHULL��55      $��10q�6)   ���	#FF8522BD���	#FF8522BD.��56      � $	��150��6   .+�57        $
 Build=�6.   $��Center=�6;   �� 58      $��Center=�6    $��CONVEX HULL��6=   $��Champagne & Limousines)�6P   59      5:      �� 5<      -   5        $	 PICTURE��5<      $��10q�6&   ���	#FF8522BD���	#FF8522BD.��5=      � $	��150��6   .+�5>        $
 Build=�6.   $��Center=�6;   �� 5?      $��Center=�6    $��PICTURE��6=   $��Champagne & Limousines)�6L   5@      5A      5B      �� 5C   
   -   5         ��Name$ 
ActiveItem��5C      $��2��6-   $��2��6=   6L   5D      5E      