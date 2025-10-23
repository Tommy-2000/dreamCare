import 'dart:async';

import 'package:flutter_riverpod/flutter_riverpod.dart';

class YearNotifier extends Notifier<DateTime> {

  @override
  DateTime build() => DateTime.now();

  void setYear(int yearOffset) {
    DateTime newState = DateTime(state.year + yearOffset);
    state = newState;
  }
}
