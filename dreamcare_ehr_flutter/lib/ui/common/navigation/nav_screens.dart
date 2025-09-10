import '../../screens/appointments/appointments_screen.dart';
import '../../screens/dashboard/dashboard_screen.dart';
import '../../screens/filespace/filespace_screen.dart';
import '../../screens/triage/triage_screen.dart';
import 'package:flutter/material.dart';

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
    navScreen: AppointmentsScreen(),
    navScreenName: "Appointments",
    navScreenIcon: Icons.calendar_month_rounded,
  ),
  NavScreen(
    navScreen: TriageScreen(),
    navScreenName: "Triage",
    navScreenIcon: Icons.email_rounded,
  ),
  NavScreen(
    navScreen: FileSpaceScreen(),
    navScreenName: "FileSpace",
    navScreenIcon: Icons.file_copy_rounded,
  ),
];
