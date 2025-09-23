import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

import '../../ui/common/navigation/nav_screens.dart';
import '../../ui/screens/root/root_scaffold.dart';

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
                path: "/appointments",
                pageBuilder: (context, state) =>
                    MaterialPage(child: navScreens[1].navScreen),
              ),
            ],
          ),
          StatefulShellBranch(
            routes: [
              GoRoute(
                path: "/triage",
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
        ],
      ),
    ],
    redirect: (context, state) {
      final validWebRoutes = [
        '/dashboard',
        '/appointments',
        '/triage',
        '/filespace',
        '/account',
        '/account/settings',
      ];
      if (!validWebRoutes.contains(state.uri.path)) {
        return '/404';
      } else {
        return null;
      }
    },
  );

  GoRouterDelegate getParentGoRouterDelegate() {
    return parentGoRouter.routerDelegate;
  }

}
