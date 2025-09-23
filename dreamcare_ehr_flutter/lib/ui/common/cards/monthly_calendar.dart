import 'package:flutter/material.dart';

class MonthlyCalendar extends StatefulWidget {
  const MonthlyCalendar({super.key});

  @override
  State<MonthlyCalendar> createState() => _MonthlyCalendarState();
}

class _MonthlyCalendarState extends State<MonthlyCalendar> {

  // Declare the current month and a list of dates
  late DateTime currentMonth;
  late List<DateTime> dateGrid;


  @override
  void initState() {
    super.initState();
    // Set the state of the current month
    currentMonth = DateTime.now();
  }


  @override
  Widget build(BuildContext context) {
    return const Placeholder();
  }

}
