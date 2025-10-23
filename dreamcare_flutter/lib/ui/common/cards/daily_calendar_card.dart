import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

import '../ui_event.dart';
import '../ui_state.dart';
import 'content_card.dart';

class DailyCalendarCard extends ConsumerStatefulWidget with UIState, UIEvent {
  const DailyCalendarCard({super.key});

  @override
  ConsumerState<DailyCalendarCard> createState() =>
      _DailyCalendarCardState();
}

class _DailyCalendarCardState extends ConsumerState<DailyCalendarCard> {
  @override
  Widget build(BuildContext context) {
    return ContentCard(
      child: Column(
        children: [
          DayList(),
        ],
      ),
    );
  }

}

// class WeekGrid extends ConsumerWidget {
//   const WeekGrid({super.key});
//   @override
//   Widget build(BuildContext context, WidgetRef ref) {
//     final currentDay = UIState().watchDay(ref);
//     final calendarGrid = UIState().watchCalendarGrid(ref);
//     return GridView.builder(
//       gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
//         crossAxisCount: 7,
//       ),
//       itemCount: 7,
//       itemBuilder: (context, index) {
//         DateTime indexDate = calendarGrid[index];
//         bool isCurrentDay = indexDate.day == currentDay.day;
//         return Padding(
//           padding: const EdgeInsets.all(4.0),
//           child: Card(
//             color: isCurrentDay
//                 ? Colors.teal
//                 : Colors.transparent,
//             child: Text(
//               indexDate.day.toString(),
//               style: TextStyle(
//                 fontWeight: FontWeight.w500,
//                 fontSize: 20,
//                 color: isCurrentDay ? Colors.black : Colors.grey,
//               ),
//             ),
//           ),
//         );
//       },
//     );
//   }
// }

class DayList extends StatelessWidget {
  const DayList({super.key});

  @override
  Widget build(BuildContext context) {
    return Flexible(
      child: ListView.builder(itemCount: 5, itemBuilder: (context, index) {
        return ContentCard(child: Text("$index"));
      }),
    );
  }
}

