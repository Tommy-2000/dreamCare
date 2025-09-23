import 'package:flutter/material.dart';

import '../../../logic/navigation/app_go_router.dart';

class RootApp extends StatefulWidget {
  const RootApp({super.key});

  @override
  State<RootApp> createState() => _RootAppState();
}

class _RootAppState extends State<RootApp> {
  @override
  Widget build(BuildContext context) {
    return MaterialApp.router(
      debugShowCheckedModeBanner: false,
      title: 'dreamCare - EHR Platform',
      theme: ThemeData(
        useMaterial3: true,
        useSystemColors: true,
        primarySwatch: Colors.teal 
      ),
      routerConfig: AppGoRouter().parentGoRouter,
    );
  }
}
