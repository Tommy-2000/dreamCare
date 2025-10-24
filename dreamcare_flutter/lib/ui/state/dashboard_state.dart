import 'package:flutter_riverpod/flutter_riverpod.dart';

import '../../logic/providers/dashboard/dashboard_providers.dart';

mixin class DashboardState {

  int statWeeklyPatients(WidgetRef ref) => ref.watch(weeklyPatientsStatProvider);

  int statWeeklyReferrals(WidgetRef ref) => ref.watch(weeklyReferralsStatProvider);

}
