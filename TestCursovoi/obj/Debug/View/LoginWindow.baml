   M S B A M L   `   `   `  ����G  CTestCursovoi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TestCursovoiTestCursovoi  5   	       TestCursovoi.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TestCursovoi     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  
MainWindow��5	   	   $	��400��6   $	��500��6)    � AllowsTransparency . 
������  � WindowStyle$
 None=�5
   <    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6   y�5   &   �� *
Visibility+ �� Mode$ TwoWay=�.��5      � .+�5   
   �� $	��400��6   $��25q�6    
�������$��Center=�6?   $	��400��6Z    �� CornerRadius$ 20��6j    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#   	   Color$	 	LightGray��63   
   ShadowDepth$
 0Q�6E      RenderingBias$ Quality=�6U   ._�5      � .+�5      �� $��30q�6   .+�5      �� $/��)pack://application:,,,/Resources/icon.ico��6   $��70��6O   $��Center=�6Z   $��5q�6w   �� 5      $��Авторизация��6    $��20(�63   $��Center=�6A   �� 5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��6m    %  !MaterialDesignFloatingHintTextBox#��[  6�   ��6   �� *
Username+6�   G� 5      -   5         G�Name$ passwordBox��5   "    . $! Введите пароль��6l    ) %MaterialDesignFloatingHintPasswordBox#��[ 6�   �� 5      $��Center=�68   
���  ��$��0 10 0 0q�6f   $
��Wrap=�6x   ��6    �� *Status+6x   �� 5      $	��150��6   $��
Войти��6)   $��0 15 0 0q�69   ��6K   �� *LoginCommand+$ OneTime=���6z   ��  �� ElementName$ passwordBox��5      �� 5      $��Right=�6   .+�5      �� -   5        $��40��5      $��40��6(   $��15q�64    & "MaterialDesignFloatingActionButton#��[ 6@   
������ .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�62   ���#3700b3$��20��6T   $��20��6`   5      5      5       5!      5"      5#      