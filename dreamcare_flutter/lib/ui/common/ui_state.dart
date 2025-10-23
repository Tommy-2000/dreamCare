import 'package:flutter_riverpod/flutter_riverpod.dart';

import '../../logic/state/common/common_ui_providers.dart';

mixin class UIState {

  // Calendar state
  DateTime watchDay(WidgetRef ref) => ref.watch(currentDayProvider);
  DateTime watchMonth(WidgetRef ref) => ref.watch(currentMonthProvider);
  DateTime watchYear(WidgetRef ref) => ref.watch(currentYearProvider);
  List<DateTime> watchCalendarGrid(WidgetRef ref) => ref.watch(calendarGridProvider);

}
