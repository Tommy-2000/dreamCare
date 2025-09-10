import '../../screens/appointments/appointments_screen.dart';
import '../../screens/calendar/calendar_screen.dart';
import '../../screens/dashboard/dashboard_screen.dart';
import '../../screens/filespace/filespace_screen.dart';
import '../../screens/patients/patients_screen.dart';
import '../../screens/settings/settings_screen.dart';
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
    navScreen: PatientsScreen(),
    navScreenName: "Patients",
    navScreenIcon: Icons.group_rounded
  ),
  NavScreen(
    navScreen: TriageScreen(),
    navScreenName: "Triage",
    navScreenIcon: Icons.email_rounded,
  ),
  NavScreen(
    navScreen: CalendarScreen(),
    navScreenName: "Calendar",
    navScreenIcon: Icons.calendar_month_rounded,
  ),
  NavScreen(
    navScreen: FileSpaceScreen(),
    navScreenName: "FileSpace",
    navScreenIcon: Icons.file_copy_rounded,
  ),
  NavScreen(
    navScreen: SettingsScreen(),
    navScreenName: "Settings",
    navScreenIcon: Icons.settings_rounded
  ),
];
