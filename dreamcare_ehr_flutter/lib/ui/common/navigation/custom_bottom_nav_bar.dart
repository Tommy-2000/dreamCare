import 'package:dreamcare_ehr_flutter/logic/navigation/go_branch.dart';
import 'package:dreamcare_ehr_flutter/ui/common/navigation/nav_screen_model.dart';
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
        child: SizedBox(
          height: 60,
          child: Container(
            color: Colors.teal,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: List.generate(navScreenList.length, (navIndex) {
                return Column(
                  children: [
                    IconButton(
                      mouseCursor: SystemMouseCursors.click,
                      icon: navScreenList[navIndex].navScreenIcon,
                      onPressed: () => {
                        if (kDebugMode) {
                          print("CustomBottomNavBar button has been tapped")
                        },
                        GoBranch().goToBranch(navIndex, widget.navigationShell),
                      },
                    ),
                    navScreenList[navIndex].navScreenName
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
