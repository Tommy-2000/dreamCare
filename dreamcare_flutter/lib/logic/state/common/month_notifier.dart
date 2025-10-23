import 'dart:async';

import 'package:flutter_riverpod/flutter_riverpod.dart';

class MonthNotifier extends Notifier<DateTime> {

  @override
  DateTime build() => DateTime.now();

  void setMonth(int monthOffset) {
    DateTime newState = DateTime(state.year, state.month + monthOffset);
    state = newState;
  }
}
