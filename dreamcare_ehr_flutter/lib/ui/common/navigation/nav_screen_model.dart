import '../../screens/appointments/appointments_screen.dart';
import '../../screens/calendar/calendar_screen.dart';
import '../../screens/dashboard/dashboard_screen.dart';
import '../../screens/filespace/filespace_screen.dart';
import '../../screens/patients/patients_screen.dart';
import '../../screens/settings/settings_screen.dart';
import '../../screens/triage/triage_screen.dart';
import 'package:flutter/material.dart';

class NavScreenModel {
  final Widget navScreen;
  final Text navScreenName;
  final Icon navScreenIcon;

  NavScreenModel({
    required this.navScreen,
    required this.navScreenName,
    required this.navScreenIcon,
  });
}

List<NavScreenModel> navScreenList = [
  NavScreenModel(
    navScreen: DashboardScreen(),
    navScreenName: Text("Dashboard", style: TextStyle(color: Colors.white)),
    navScreenIcon: Icon(Icons.home_rounded, color: Colors.white),
  ),
  NavScreenModel(
    navScreen: AppointmentsScreen(),
    navScreenName: Text("Appointments", style: TextStyle(color: Colors.white)),
    navScreenIcon: Icon(Icons.calendar_month_rounded, color: Colors.white),
  ),
  NavScreenModel(
    navScreen: PatientsScreen(),
    navScreenName: Text("Patients", style: TextStyle(color: Colors.white)),
    navScreenIcon: Icon(Icons.group_rounded, color: Colors.white),
  ),
  NavScreenModel(
    navScreen: TriageScreen(),
    navScreenName: Text("Triage", style: TextStyle(color: Colors.white)),
    navScreenIcon: Icon(Icons.email_rounded, color: Colors.white),
  ),
  NavScreenModel(
    navScreen: CalendarScreen(),
    navScreenName: Text("Calendar", style: TextStyle(color: Colors.white)),
    navScreenIcon: Icon(Icons.calendar_month_rounded, color: Colors.white),
  ),
  NavScreenModel(
    navScreen: FileSpaceScreen(),
    navScreenName: Text("FileSpace", style: TextStyle(color: Colors.white)),
    navScreenIcon: Icon(Icons.file_copy_rounded, color: Colors.white),
  ),
  NavScreenModel(
    navScreen: SettingsScreen(),
    navScreenName: Text("Settings", style: TextStyle(color: Colors.white)),
    navScreenIcon: Icon(Icons.settings_rounded, color: Colors.white),
  ),
];
