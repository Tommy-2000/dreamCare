import 'package:flutter_riverpod/flutter_riverpod.dart';

import '../../logic/state/common/common_ui_providers.dart';

mixin class UIEvent {

  // Calendar UI Events
  void updateDay(WidgetRef ref, int dayOffset) {
    ref.read(currentDayProvider.notifier).setDay(dayOffset);
  }

  void updateMonth(WidgetRef ref, int monthOffset) {
    ref.read(currentMonthProvider.notifier).setMonth(monthOffset);
  }

  void updateYear(WidgetRef ref, int yearOffset) {
    ref.read(currentYearProvider.notifier).setYear(yearOffset);
  }

  void updateCalendarGrid(WidgetRef ref, DateTime setMonth) {
    ref.read(calendarGridProvider.notifier).setCalendarGrid(setMonth);
  }
}
