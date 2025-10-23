import 'package:flutter_riverpod/flutter_riverpod.dart';

// Status providers

final weeklyPatientsStatProvider = Provider(isAutoDispose: true, (_) => 47);

final weeklyReferralsStatProvider = Provider(isAutoDispose: true, (_) => 12);

