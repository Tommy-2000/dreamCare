import 'package:dreamcare_ehr_flutter/ui/common/navigation/nav_screen_model.dart';
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
      borderRadius: BorderRadius.all(Radius.circular(30)),
      child: Container(
        color: Colors.teal,
        child: Padding(
          padding: const EdgeInsets.all(30),
          child: SizedBox(
            child: Column(
              children: [
                IconButton(
                  onPressed: () {},
                  icon: Icon(Icons.menu_rounded, color: Colors.white),
                ),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: List.generate(navScreenList.length, (navIndex) {
                      return Column(
                        children: [
                          IconButton(
                            mouseCursor: SystemMouseCursors.click,
                            focusColor: Colors.teal,
                            icon: navScreenList[navIndex].navScreenIcon,
                            onPressed: () {
                              if (kDebugMode) {
                                print("CustomNavRail button has been tapped");
                              }
                              GoBranch().goToBranch(
                                navIndex,
                                widget.navigationShell,
                              );
                            },
                          ),
                          navScreenList[navIndex].navScreenName
                        ],
                      );
                    }),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
