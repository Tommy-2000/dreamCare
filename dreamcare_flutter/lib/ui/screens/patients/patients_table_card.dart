import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:gap/gap.dart';

import '../../../logic/utils/constants.dart';
import '../../common/buttons/primary_button.dart';
import '../../common/cards/content_card.dart';
import 'patient_search_bar.dart';

class PatientTableCard extends ConsumerStatefulWidget {
  const PatientTableCard({super.key});

  @override
  ConsumerState createState() => _PatientTableCardState();
}

class _PatientTableCardState extends ConsumerState<PatientTableCard> {
  @override
  Widget build(BuildContext context) {
    return ContentCard(
      child: Padding(
        padding: EdgeInsetsGeometry.all(cardPadding),
        child: ContentCard(
          child: Column(
            children: [
              ContentCard(
                child: Row(
                  children: [
                    Column(
                      children: [
                        PrimaryButton(
                          buttonText: "Export",
                          buttonIcon: Icon(Icons.download_rounded, size: 15.0),
                        ),
                      ],
                    ),
                    Gap(5),
                    Column(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        PatientSearchBar()
                      ],
                    )
                  ],
                ),
              ),
              Table(
                border: TableBorder.all(
                  style: BorderStyle.solid,
                  borderRadius: BorderRadius.all(Radius.circular(10)),
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
                        child: ContentCard(child: Text("Patient Name")),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: ContentCard(child: Text("Contact Details")),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: ContentCard(child: Text("Date Of Birth")),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: ContentCard(child: Text("Patient Status")),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: ContentCard(child: Text("Assigned GP")),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: ContentCard(child: Text("Last Visit")),
                      ),
                    ],
                  ),
                  TableRow(
                    children: <Widget>[
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.red,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.green,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.blue,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.red,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.green,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.blue,
                        ),
                      ),
                    ],
                  ),
                  TableRow(
                    children: <Widget>[
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.red,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.green,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.blue,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.red,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.green,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.top,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.blue,
                        ),
                      ),
                    ],
                  ),
                  TableRow(
                    children: <Widget>[
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.red,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.green,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.blue,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.red,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.green,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.blue,
                        ),
                      ),
                    ],
                  ),
                  TableRow(
                    children: <Widget>[
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.red,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.green,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.blue,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.red,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.green,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.blue,
                        ),
                      ),
                    ],
                  ),
                  TableRow(
                    children: <Widget>[
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.red,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.green,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.blue,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.red,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.green,
                        ),
                      ),
                      TableCell(
                        verticalAlignment: TableCellVerticalAlignment.fill,
                        child: Container(
                          height: 32,
                          width: 32,
                          color: Colors.blue,
                        ),
                      ),
                    ],
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}
