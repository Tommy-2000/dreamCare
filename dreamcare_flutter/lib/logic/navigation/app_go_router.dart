import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

import '../../ui/common/navigation/nav_screens.dart';
import '../../ui/root/not_found_screen.dart';
import '../../ui/root/root_scaffold.dart';

class AppGoRouter {
  final parentGoRouter = GoRouter(
    initialLocation: "/dashboard",
    routes: [
      StatefulShellRoute.indexedStack(
        builder: (context, state, navShell) {
          return RootScaffold(navigationShell: navShell);
        },
        branches: [
          StatefulShellBranch(
            routes: [
              GoRoute(
                path: "/dashboard",
                pageBuilder: (context, state) =>
                    MaterialPage(child: navScreens[0].navScreen),
              ),
            ],
          ),
          StatefulShellBranch(
            routes: [
              GoRoute(
                path: "/schedule",
                pageBuilder: (context, state) =>
                    MaterialPage(child: navScreens[1].navScreen),
              ),
            ],
          ),
          StatefulShellBranch(
            routes: [
              GoRoute(
                path: "/patients",
                pageBuilder: (context, state) =>
                    MaterialPage(child: navScreens[2].navScreen),
              ),
            ],
          ),
          StatefulShellBranch(
            routes: [
              GoRoute(
                path: "/filespace",
                pageBuilder: (context, state) =>
                    MaterialPage(child: navScreens[3].navScreen),
              ),
            ],
          ),
          StatefulShellBranch(
            routes: [
              GoRoute(
                path: "/teamspace",
                pageBuilder: (context, state) =>
                    MaterialPage(child: navScreens[4].navScreen),
              ),
            ],
          ),
          StatefulShellBranch(
            routes: [
              GoRoute(
                path: "/account",
                pageBuilder: (context, state) =>
                    MaterialPage(child: navScreens[5].navScreen),
              ),
            ],
          ),
        ],
      ),
    ],
    redirect: (context, state) {
      final validRoutes = [
        '/dashboard',
        '/schedule',
        '/patients',
        '/filespace',
        '/teamspace',
        '/account',
      ];
      if (!validRoutes.contains(state.uri.path)) {
        return '/404';
      } else {
        return null;
      }
    },
    errorBuilder: (context, state) =>
        NotFoundScreen(goRouterException: state.error),
  );

  GoRouterDelegate getParentGoRouterDelegate() {
    return parentGoRouter.routerDelegate;
  }
}
