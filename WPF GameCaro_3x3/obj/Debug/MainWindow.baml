   M S B A M L   `   `   `  ????K  GWPF GameCaro_3x3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPF_GameCaro_3x3WPF_GameCaro_3x3  5   	   !    WPF_GameCaro_3x3.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPF_GameCaro_3x3     5   	   -   5          ? 
ResizeMode$  NoResize=?5       ? Icon$ Caro.jpg??60    ? Title$ 
MainWindow??5   	   $	??350??6   $	??450??6)   .??5	      ]? 
????  ?.+?5
   
   ?? $??Right=?6   $	??100??6,   $??
10 10 10 0q?68   .+?5      ?? -   5         ??Name$ tblTurn??5      $
??Caro??6)   
??????? ?? TextAlignment$ Center=?6H   $??20??6_   ? 5      .+?5      ?? -   5        $ 
tblViewImg??5       K? ZIndex$ 10??60   $??0 10 0 0q?6B   $ Center=?6T   $	??100??6k   ??5      ?? 5       ?? ImageSource$ Caro.jpg??6%   5      ?? 5      -   5        $ 
tblViewWrd??5      $ 9??60   $??0 10 0 0q?6A   $ Center=?6S   $	??100??6j   5      ?? 5      -   5         ??Name$ btnNew??5      $??0 50 0 0q?6:   $??50??6L   $??New game??6X   ?? 5      -   5        $ btnOp??5      $??0 10 0 0q?68   $??50??6J   $??Opiton??6V   5      ?? 5   
   
???????$??5q?6+   ._?5      ? -   5         ?Name$	 grd??5      $	??300??6    $	??300??6,   	 ? ColumnDefinitions	 5      ?? 5      6)   ?? 5      6)   ?? 5      6)   
 ? RowDefinitions
 5      ?? 5      6&   ?? 5       6&   ?? 5!      6&   5#      5$      5%      5&      