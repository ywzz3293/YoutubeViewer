   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPF.ComponentsWPF.Components  5      *    $WPF.Components.YoutubeViewersDetails   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WPF.Components     5      .��5	      � .+�5
   
   ��   �� Padding$  20q�5         BorderPrimary#��[  5      $��1q�5       �� CornerRadius$ 5��5       J� SnapsToDevicePixels$
 True��5      ._�5      � .+�5"      �  � IsSharedSizeScope$
 True��6    � RowDefinitions 5-      �� 5.      $
��auto �6(   �� 5/      $
��auto �6(   �� 50      $
��auto �6(   .+�53      �� $��0��54      $��24(�55      $
��Wrap=�57      ��56      �� *
Username+57      � 59      $��1��6   $��0 20 0 0q�6(    � ColumnDefinitions 5:      �� 5;      $
��auto �6/    z� SharedSizeGroup$ Label��6<   �� 5<      $
��auto �6/   .+�5?      �� $��0��5@      $
��Bold"�5A      $��Is Subscribed?��5B      �� 5D      $��1��5E      $��20 0 0 0q�5F      ��5G      �� *IsSubscribedDisplay+5H      � 5J      $��2��6   $��0 20 0 0q�6(    5K      �� 5L      $
��auto �6/   $ Label��6<   �� 5M      $
��auto �6/   .+�5P      �� $��0��5Q      $
��Bold"�5R      $��
Is Member?��5S      �� 5U      $��1��5V      $��20 0 0 0q�5W      ��5X      �� *IsMemberDisplay+5Y      5Z      5[      5\      5]      5^      