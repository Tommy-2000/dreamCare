import 'package:flutter_riverpod/flutter_riverpod.dart';

import '../../../logic/state/common/common_ui_providers.dart';
import '../../../logic/state/dashboard/dashboard_providers.dart';

mixin class DashboardState {

  String testText(WidgetRef ref) => ref.watch(testTextProvider);

  int statWeeklyPatients(WidgetRef ref) => ref.watch(weeklyPatientsStatProvider);

  int statWeeklyReferrals(WidgetRef ref) => ref.watch(weeklyReferralsStatProvider);

}
