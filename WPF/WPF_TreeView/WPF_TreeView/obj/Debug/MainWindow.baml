   M S B A M L   `   `   `  ����G  CWPF_TreeView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPF_TreeViewWPF_TreeView  5   	       WPF_TreeView.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WPF_TreeView     5   	     � Title$  Files and Directories��5   	   $	��450��6'   $	��800��64   .��5	      �  � RowDefinitions 5
   
   �� 5      $��9* �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��7* �6   �� 5      .+�5   
   �� -   5         ��Name$ 
showButton��5      $��1��5      $��2��6   $
��Show��5      $��10q�5      5      �� 5   
   -   5         ��Name$ image��5      $��0��5      $��0��6    $��images.jpeg��5      $
��Fill=�5      $��10,10,200,0q�5      � 5   
   -   5         �Name$ progressBar��5      $��1��5      $��0��5      $
��30,5q�5      $y�Hidden=�5       5"      R� 5#   
   -   5         R�Name$ treeView��5$      $��10q�5#      $��17(�5%      $y�Hidden=�5&      5(      � 5)   
   -   5         �Name$ popup��5,       � 	StaysOpen .  $��
MousePoint=�5*      	 � AllowsTransparency	 . .��5-      �� -   5        
 ��Name$
 	popupText��50      $	��160��5-      $	��260��5.      
����� � �� 
IsReadOnly .  �� TextWrapping$
 Wrap=�52      $��20(�53      .��6$   55      56      57      58      