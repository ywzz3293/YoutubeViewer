   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPF.ComponentsWPF.Components  5      P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl 69   -    'WPF.Components.YouTubeViewerDetailsForm   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WPF.Components     5      dloadingspinnercontrolBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     69     � 	Resources  5	          BooleanToVisibilityConverter��%   &	        �� 5
   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6    � IsSharedSizeScope$
 True��6    5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      $
��auto �6'    z� SharedSizeGroup$ Label��64   �� 5      $��* �6'   $	��250��61   .+�5       �� $��0��5!      $
��Bold"�5"      $��Username��5#      �� 5%      $��1��5&      $��20,0,0,0q�5'      4  .System.Windows.Automation.AutomationProperties   AutomationId$" YouTubeViewerUsernameTextBox��5(      ��5)      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5*      � 5,      $��1��6   $��0,20,0,0q�6     5-      �� 5.      $
��auto �6'   $ Label��64   �� 5/      $
��auto �6'   .+�52      �� $��0��53      $
��Bold"�54      $��Is Subscribed?��55      �� 57      $��1��58      $��20,0,0,0q�59      $��Center=�5:      $% YouTubeViewerSubscribedCheckBox��5;       d� 	IsChecked 5<      �� *IsSubscribed+5=      � 5?      $��2��6   $��0,20,0,0q�6     5@      �� 5A      $
��auto �6'   $ Label��64   �� 5B      $
��auto �6'   .+�5E      �� $��0��5F      $
��Bold"�5G      $��
Is Member?��5H      �� 5J      $��1��5K      $��20,0,0,0q�5L      $��Center=�5M      $! YouTubeViewerMemberCheckBox��5N       5O      �� *
IsMember+5P      5Q      � 5S   
   $��1��6   $��0,30,0,0q�6!   .+�5T      �� $��0,0,5,0q�5U      $ YouTubeViewerSubmitButton��5V      $��Submit��5X      ��5W      �� *SubmitCommand+{�5Y      �� *	CanSubmit+�� 5Z      $��0,0,5,0q�5[      $��Cancel��5]        ButtonSecondary#��[ 5^      ��5\      �� *CancelCommand+5^      *  $LoadingSpinnerControl.LoadingSpinner  5_         Diameter$ 25Q�5`      	   	Thickness$	 2Q�5b      
   	IsLoading
 5a      �� *IsSubmitting+5b      5c      �� 5d   
   $��2��5e      $��0,15,0,0q�5f        ErrorMessage#��[ 5g      ��5h      �� *ErrorMessage+y�5i      �� *HasErrorMessage+ �� 	Converter# [  5j      5k      