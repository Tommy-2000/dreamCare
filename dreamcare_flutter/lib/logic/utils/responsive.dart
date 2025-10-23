

import 'package:flutter/material.dart';

class Responsive {
  static bool screenIsSmall(BuildContext context) => 
    MediaQuery.of(context).size.width < 850;

  static bool screenIsMedium(BuildContext context) =>
    MediaQuery.of(context).size.width < 1100 &&
    MediaQuery.of(context).size.width >= 850;
  
  static bool screenIsLarge(BuildContext context) => 
    MediaQuery.of(context).size.width >= 1100;
}
