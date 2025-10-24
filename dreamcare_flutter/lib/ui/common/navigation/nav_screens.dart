import 'package:cached_network_image/cached_network_image.dart';

import '../../screens/account/account_screen.dart';
import '../../screens/dashboard/dashboard_screen.dart';
import '../../screens/filespace/filespace_screen.dart';
import '../../screens/patients/patients_screen.dart';
import 'package:flutter/material.dart';

import '../../screens/schedule/schedule_screen.dart';
import '../../screens/settings/settings_screen.dart';
import '../../screens/teamspace/teamspace_screen.dart';

class NavScreen {
  final Widget navScreen;
  final String navScreenName;
  final Widget navScreenIcon;

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
    navScreenIcon: Icon(Icons.home_rounded, color: Colors.white),
  ),
  NavScreen(
    navScreen: ScheduleScreen(),
    navScreenName: "Schedule",
    navScreenIcon: Icon(Icons.calendar_month_rounded, color: Colors.white),
  ),
  NavScreen(
    navScreen: PatientsScreen(),
    navScreenName: "Patients",
    navScreenIcon: Icon(Icons.person_4_rounded, color: Colors.white),
  ),
  NavScreen(
    navScreen: FileSpaceScreen(),
    navScreenName: "FileSpace",
    navScreenIcon: Icon(Icons.file_copy_rounded, color: Colors.white),
  ),
  NavScreen(
    navScreen: TeamSpaceScreen(),
    navScreenName: "TeamSpace",
    navScreenIcon: Icon(Icons.groups_3_rounded, color: Colors.white),
  ),
  NavScreen(
    navScreen: AccountScreen(),
    navScreenName: "Account",
    navScreenIcon: CircleAvatar(
      backgroundImage: CachedNetworkImageProvider(
        "https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&q=80&w=1974",
      ),
      radius: 20,
    ),
  ),
];
