   M S B A M L   `   `   `  ����F  BWPF_Gallery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_GalleryWPF_Gallery  5   	       WPF_Gallery.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPF_Gallery     5   	     � Title$  Gallery��5   	   $	��525��6   $	��525��6&   .��5	      ]� .+�5
   
   o� $��17(�6   $	��Top=�5      .@�5      m� -   5        $
��Open��5      6%   m� 5      -   5        $
��Save��5      6%   5      �� 5   
   $��17(�6   $��Bottom=�5      .@�5      �� -   5         ��Name$ label��5      6%   5      � 5   
    � RowDefinitions 5      �� 5      $
��0.5* �6    �� 5      .+�5      A�  A� Columns$ 4��6   $��0��6&   .+�5      �� -   5         ��Name$ image1��5      $��5q�5      $
��Fill=�5      $��0��5      
 � Tag$ im1.jpg��5      5      �� 5      -   5        $ image2��5       $��5q�5      $
��Fill=�5!      $ im2.jpg��5"      $��1��5#      5$      �� 5%      -   5        $ image3��5&      $��5q�5%      $
��Fill=�5'      $ im3.jpg��5(      $��1��5)      5*      �� 5+      -   5        $ image4��5,      $��5q�5+      $��3��5-      $
��Fill=�5.      $ im4.jpg��5/      51      52      �� 53      -   5        $ currentImage��53      $��5q�54      $��1��6   $
��Fill=�55       �� StretchDirection$
 Both=�56      6.   57      59      5:      