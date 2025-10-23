import './calendar_grid_notifier.dart';
import './day_notifier.dart';
import './month_notifier.dart';
import './year_notifier.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

// Test providers

final testTextProvider = Provider(isAutoDispose: true, (_) => 'Test text');

// Calendar providers

final currentDayProvider = NotifierProvider<DayNotifier, DateTime>(
  isAutoDispose: true,
  DayNotifier.new,
);

final currentMonthProvider = NotifierProvider<MonthNotifier, DateTime>(
  isAutoDispose: true,
  MonthNotifier.new,
);

final currentYearProvider = NotifierProvider<YearNotifier, DateTime>(
  isAutoDispose: true,
  YearNotifier.new,
);

final calendarGridProvider = NotifierProvider<CalendarGridNotifier, List<DateTime>>(
  isAutoDispose: true,
  CalendarGridNotifier.new,
);
