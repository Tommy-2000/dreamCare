import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

import '../../../logic/utils/constants.dart';
import '../../common/cards/content_card.dart';

class TeamSpaceTableCard extends ConsumerStatefulWidget {
  const TeamSpaceTableCard({super.key});

  @override
  ConsumerState createState() => _PatientTableCardState();
}

class _PatientTableCardState extends ConsumerState<TeamSpaceTableCard> {
  @override
  Widget build(BuildContext context) {
    return ContentCard(
      child: Padding(
        padding: EdgeInsetsGeometry.all(cardPadding),
        child: ContentCard(
          child: Table(
            border: TableBorder.all(
              style: BorderStyle.solid,
              borderRadius: BorderRadius.all(Radius.circular(10))
            ),
              columnWidths: const <int, TableColumnWidth>{
                0: FlexColumnWidth(),
                1: FlexColumnWidth(),
                2: FlexColumnWidth(),
                3: FlexColumnWidth(),
                4: FlexColumnWidth(),
                5: FlexColumnWidth(),
                6: FlexColumnWidth(),
              },
              defaultVerticalAlignment: TableCellVerticalAlignment.middle,
              children: <TableRow>[
                TableRow(
                  children: <Widget>[
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                  ],
                ),
                TableRow(
                  children: <Widget>[
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                  ],
                ),
                TableRow(
                  children: <Widget>[
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.top,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                  ],
                ),
                TableRow(
                  children: <Widget>[
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                  ],
                ),
                TableRow(
                  children: <Widget>[
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                  ],
                ),
                TableRow(
                  children: <Widget>[
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.red),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.green),
                    ),
                    TableCell(
                      verticalAlignment: TableCellVerticalAlignment.fill,
                      child: Container(height: 32, width: 32, color: Colors.blue),
                    ),
                  ],
                ),
          ]),
        ),
      ),
    );
  }
}
