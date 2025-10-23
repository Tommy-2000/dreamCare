import '../../screens/account/account_screen.dart';
import '../../screens/dashboard/dashboard_screen.dart';
import '../../screens/filespace/filespace_screen.dart';
import '../../screens/patients/patients_screen.dart';
import 'package:flutter/material.dart';

import '../../screens/schedule/schedule_screen.dart';

class NavScreen {
  final Widget navScreen;
  final String navScreenName;
  final IconData navScreenIcon;

  NavScreen({
    required this.navScreen,
    required this.navScreenName,
    required this.navScreenIcon,
  });
}

List<NavScreen> navScreens = [
  NavScreen(
    navScreen: DashboardScreen(),
    navScreenName: "Dashboard",
    navScreenIcon: Icons.home_rounded,
  ),
  NavScreen(
    navScreen: ScheduleScreen(),
    navScreenName: "Schedule",
    navScreenIcon: Icons.calendar_month_rounded,
  ),
  NavScreen(
    navScreen: PatientsScreen(),
    navScreenName: "Patients",
    navScreenIcon: Icons.group_rounded,
  ),
  NavScreen(
    navScreen: FileSpaceScreen(),
    navScreenName: "FileSpace",
    navScreenIcon: Icons.file_copy_rounded,
  ),
  NavScreen(
    navScreen: AccountScreen(),
    navScreenName: "Account",
    navScreenIcon: Icons.account_circle_rounded,
  ),
];
