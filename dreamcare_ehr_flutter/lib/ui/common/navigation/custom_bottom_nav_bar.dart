import 'dart:ui';

import 'package:dreamcare_ehr_flutter/logic/navigation/app_go_branch.dart';
import 'package:dreamcare_ehr_flutter/ui/common/navigation/nav_screens.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import 'package:logging/logging.dart';

class CustomBottomNavBar extends ConsumerStatefulWidget {
  CustomBottomNavBar(this.navigationShell, {super.key});

  final uiDebugLogger = Logger("uiDebugLogger");

  final StatefulNavigationShell navigationShell;

  @override
  ConsumerState<CustomBottomNavBar> createState() => _CustomBottomNavBarState();
}

class _CustomBottomNavBarState extends ConsumerState<CustomBottomNavBar> {
  @override
  Widget build(BuildContext context) {
    if (kDebugMode) {
      print("CustomBottomNavBar has been built");
    }
    return Padding(
      padding: const EdgeInsets.all(30),
      child: ClipRRect(
        borderRadius: BorderRadius.all(Radius.circular(30)),
        child: Container(
          color: Colors.teal,
          child: BackdropFilter(
            filter: ImageFilter.blur(sigmaX: 25, sigmaY: 25),
            child: SizedBox(
              height: 60,
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: List.generate(navScreens.length, (navIndex) {
                  return Column(
                    children: [
                      IconButton(
                        mouseCursor: SystemMouseCursors.click,
                        icon: Icon(navScreens[navIndex].navScreenIcon),
                        onPressed: () => {
                          if (kDebugMode) {
                            print("CustomBottomNavBar button has been tapped")
                          },
                          AppGoBranch().goToBranch(navIndex, widget.navigationShell),
                        },
                      ),
                      Text(navScreens[navIndex].navScreenName, style: TextStyle(color: Colors.white))
                    ],
                  );
                }),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
