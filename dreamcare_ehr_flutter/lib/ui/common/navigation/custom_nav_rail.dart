import 'package:dreamcare_ehr_flutter/ui/common/navigation/nav_screens.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import 'package:logging/logging.dart';

import '../../../logic/navigation/go_branch.dart';

class CustomNavRail extends ConsumerStatefulWidget {
  CustomNavRail(this.navigationShell, {super.key});

  final uiDebugLogger = Logger("uiDebugLogger");

  final StatefulNavigationShell navigationShell;

  @override
  ConsumerState<CustomNavRail> createState() => _CustomNavRailState();
}

class _CustomNavRailState extends ConsumerState<CustomNavRail> {
  @override
  Widget build(BuildContext context) {
    if (kDebugMode) {
      print("CustomNavRail has been built");
    }
    return ClipRRect(
      borderRadius: BorderRadius.circular(60),
      child: Container(
        color: Colors.teal,
        width: 125,
        child: Padding(
          padding: const EdgeInsets.all(10),
          child: SizedBox(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: List.generate(navScreens.length, (navIndex) {
                return Column(
                  children: [
                    MaterialButton(
                      mouseCursor: SystemMouseCursors.click,
                      focusColor: Colors.white,
                      child: Column(
                        children: [
                          Icon(navScreens[navIndex].navScreenIcon, color: Colors.white),
                          Text(navScreens[navIndex].navScreenName, style: TextStyle(color: Colors.white)),
                        ],
                      ),
                      onPressed: () {
                        if (kDebugMode) {
                          print(
                            "CustomNavigationRail button has been tapped",
                          );
                        }
                        GoBranch().goToBranch(
                          navIndex,
                          widget.navigationShell,
                        );
                      },
                    ),
                  ],
                );
              }),
            ),
          ),
        ),
      ),
    );
  }
}
