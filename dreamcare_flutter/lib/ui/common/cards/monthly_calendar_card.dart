import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../logic/utils/constants.dart';
import '../../../styles/colours.dart';
import '../../state/common_event.dart';
import '../../state/common_state.dart';
import 'content_card.dart';

class MonthlyCalendarCard extends ConsumerStatefulWidget with CommonState, CommonEvent {
  const MonthlyCalendarCard({super.key});

  @override
  ConsumerState<MonthlyCalendarCard> createState() =>
      _MonthlyCalendarCardState();
}

class _MonthlyCalendarCardState extends ConsumerState<MonthlyCalendarCard> {
  @override
  Widget build(BuildContext context) {
    final currentMonth = CommonState().watchMonth(ref);
    return ContentCard(
      child: Padding(
        padding: const EdgeInsets.all(cardPadding),
        child: Column(
          children: [
            Flexible(
              child: Row(
                children: [
                  IconButton(
                    onPressed: () => changeMonthGrid(ref, -1, currentMonth),
                    icon: Icon(Icons.arrow_back_rounded),
                  ),
                  Text(
                    '${_monthName(currentMonth.month)} ${currentMonth.year}',
                    style: const TextStyle(
                      fontSize: 24,
                      fontWeight: FontWeight.w500,
                    ),
                  ),
                  IconButton(
                    onPressed: () => changeMonthGrid(ref, 1, currentMonth),
                    icon: Icon(Icons.arrow_forward_rounded),
                  ),
                ],
              ),
            ),
            Flexible(
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: List.generate(
                  7,
                  (index) => ContentCard(
                    child: Text(
                      [
                        'Mon',
                        'Tues',
                        'Wed',
                        'Thurs',
                        'Fri',
                        'Sat',
                        'Sun',
                      ][index],
                      style: GoogleFonts.montserrat(
                        fontSize: 15,
                        fontWeight: FontWeight.bold,
                        color: primaryTextColour,
                      ),
                    ),
                  ),
                ),
              ),
            ),
            CalendarGrid(),
          ],
        ),
      ),
    );
  }

  String _monthName(int monthNumber) {
    return [
      'January',
      'February',
      'March',
      'April',
      'May',
      'June',
      'July',
      'August',
      'September',
      'October',
      'November',
      'December',
    ][monthNumber - 1];
  }
}

class CalendarGrid extends ConsumerWidget {
  const CalendarGrid({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final currentDay = CommonState().watchDay(ref);
    final currentMonth = CommonState().watchMonth(ref);
    final calendarGrid = CommonState().watchCalendarGrid(ref);
    return Expanded(
      flex: 12,
      child: GridView.builder(
        gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
          crossAxisCount: 7,
        ),
        itemCount: calendarGrid.length,
        itemBuilder: (context, index) {
          DateTime gridIndex = calendarGrid[index];
          bool isCurrentMonth = gridIndex.month == currentMonth.month;
          bool isCurrentDay = gridIndex.day == currentDay.day;
          return Padding(
            padding: const EdgeInsets.all(4.0),
            child: Card(
              color: isCurrentMonth
                  ? Colors.teal
                  : Colors.transparent,
              elevation: 3.0,
              child: Center(
                child: Text(
                  gridIndex.day.toString(),
                  style: TextStyle(
                    fontWeight: FontWeight.w500,
                    fontSize: 20,
                    color: isCurrentMonth ? Colors.white : Colors.grey,
                  ),
                ),
              ),
            ),
          );
        },
      ),
    );
  }
}

void changeMonthGrid(WidgetRef ref, int monthOffset, DateTime setMonth) {
  CommonEvent().updateMonth(ref, monthOffset);
  CommonEvent().updateCalendarGrid(ref, setMonth);
}

