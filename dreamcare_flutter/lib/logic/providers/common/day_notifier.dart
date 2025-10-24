import 'package:flutter_riverpod/flutter_riverpod.dart';

class DayNotifier extends Notifier<DateTime> {

  @override
  DateTime build() => DateTime.now();

  void setDay(int dayOffset) {
    DateTime newState = DateTime(state.month, state.day + dayOffset);
    state = newState;
  }
}
