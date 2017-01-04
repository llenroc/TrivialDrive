# TrivialDrive
Google IAP billing sample port to Xamarin.Android


  Example game using in-app billing version 3.
 
  Before attempting to run this sample, please read the README file. It
  contains important information on how to set up this project.
 
  All the game-specific logic is implemented here in MainActivity, while the
  general-purpose boilerplate that can be reused in any app is provided in the
  classes in the util/ subdirectory. When implementing your own application,
  you can copy over util/.java to make use of those utility classes.
 
  This game is a simple "driving" game where the player can buy gas
  and drive. The car has a tank which stores gas. When the player purchases
  gas, the tank fills up (1/4 tank at a time). When the player drives, the gas
  in the tank diminishes (also 1/4 tank at a time).
 
  The user can also purchase a "premium upgrade" that gives them a red car
  instead of the standard blue one (exciting!).
 
  The user can also purchase a subscription ("infinite gas") that allows them
  to drive without using up any gas while that subscription is active.
 
  It's important to note the consumption mechanics for each item.
 
  PREMIUM: the item is purchased and NEVER consumed. So, after the original
  purchase, the player will always own that item. The application knows to
  display the red car instead of the blue one because it queries whether
  the premium "item" is owned or not.
 
  INFINITE GAS: this is a subscription, and subscriptions can't be consumed.
 
  GAS: when gas is purchased, the "gas" item is then owned. We consume it
  when we apply that item's effects to our app's world, which to us means
  filling up 1/4 of the tank. This happens immediately after purchase!
  It's at this point (and not when the user drives) that the "gas"
  item is CONSUMED. Consumption should always happen when your game
  world was safely updated to apply the effect of the purchase. So,
  in an example scenario:
 
  BEFORE:      tank at 1/2
  ON PURCHASE: tank at 1/2, "gas" item is owned
  IMMEDIATELY: "gas" is consumed, tank goes to 3/4
  AFTER:       tank at 3/4, "gas" item NOT owned any more
 
  Another important point to notice is that it may so happen that
  the application crashed (or anything else happened) after the user
  purchased the "gas" item, but before it was consumed. That's why,
  on startup, we check if we own the "gas" item, and, if so,
  we have to apply its effects to our world and consume it. This
  is also very important!
 
